// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using TerraFX.Interop;
using TerraFX.Utilities;
using static TerraFX.Graphics.Providers.Vulkan.HelperUtilities;
using static TerraFX.Interop.VkCompareOp;
using static TerraFX.Interop.VkDescriptorPoolCreateFlagBits;
using static TerraFX.Interop.VkDescriptorType;
using static TerraFX.Interop.VkFrontFace;
using static TerraFX.Interop.VkFormat;
using static TerraFX.Interop.VkPrimitiveTopology;
using static TerraFX.Interop.VkSampleCountFlagBits;
using static TerraFX.Interop.VkShaderStageFlagBits;
using static TerraFX.Interop.VkStructureType;
using static TerraFX.Interop.VkVertexInputRate;
using static TerraFX.Interop.Vulkan;
using static TerraFX.Utilities.DisposeUtilities;
using static TerraFX.Utilities.InteropUtilities;
using static TerraFX.Utilities.State;
using TerraFX.Numerics;

namespace TerraFX.Graphics.Providers.Vulkan
{
    /// <inheritdoc />
    public sealed unsafe class VulkanGraphicsPipelineSignature : GraphicsPipelineSignature
    {
        private ValueLazy<VkDescriptorPool> _vulkanDescriptorPool;
        private ValueLazy<VkDescriptorSet> _vulkanDescriptorSet;
        private ValueLazy<VkDescriptorSetLayout> _vulkanDescriptorSetLayout;
        private ValueLazy<VkPipelineLayout> _vulkanPipelineLayout;

        private State _state;

        internal VulkanGraphicsPipelineSignature(VulkanGraphicsDevice graphicsDevice, ReadOnlySpan<GraphicsPipelineInput> inputs, ReadOnlySpan<GraphicsPipelineResource> resources)
            : base(graphicsDevice, inputs, resources)
        {
            _vulkanDescriptorPool = new ValueLazy<VkDescriptorPool>(CreateVulkanDescriptorPool);
            _vulkanDescriptorSet = new ValueLazy<VkDescriptorSet>(CreateVulkanDescriptorSet);
            _vulkanDescriptorSetLayout = new ValueLazy<VkDescriptorSetLayout>(CreateVulkanDescriptorSetLayout);
            _vulkanPipelineLayout = new ValueLazy<VkPipelineLayout>(CreateVulkanPipelineLayout);

            _ = _state.Transition(to: Initialized);
        }

        /// <summary>Finalizes an instance of the <see cref="VulkanGraphicsPipelineSignature" /> class.</summary>
        ~VulkanGraphicsPipelineSignature()
        {
            Dispose(isDisposing: true);
        }

        /// <summary>Gets the <see cref="VkDescriptorPool" /> for the pipeline.</summary>
        public VkDescriptorPool VulkanDescriptorPool => _vulkanDescriptorPool.Value;

        /// <summary>Gets the <see cref="VkDescriptorSet" /> for the pipeline.</summary>
        public VkDescriptorSet VulkanDescriptorSet => _vulkanDescriptorSet.Value;

        /// <summary>Gets the underlying <see cref="VkDescriptorSetLayout" /> for the pipeline.</summary>
        public VkDescriptorSetLayout VulkanDescriptorSetLayout => _vulkanDescriptorSetLayout.Value;

        /// <inheritdoc cref="GraphicsPipeline.GraphicsDevice" />
        public VulkanGraphicsDevice VulkanGraphicsDevice => (VulkanGraphicsDevice)GraphicsDevice;

        /// <summary>Gets the underlying <see cref="VkPipelineLayout" /> for the pipeline.</summary>
        public VkPipelineLayout VulkanPipelineLayout => _vulkanPipelineLayout.Value;

        /// <inheritdoc />
        protected override void Dispose(bool isDisposing)
        {
            var priorState = _state.BeginDispose();

            if (priorState < Disposing)
            {
                _vulkanDescriptorSet.Dispose(DisposeVulkanDescriptorSet);
                _vulkanDescriptorSetLayout.Dispose(DisposeVulkanDescriptorSetLayout);
                _vulkanDescriptorPool.Dispose(DisposeVulkanDescriptorPool);
                _vulkanPipelineLayout.Dispose(DisposeVulkanPipelineLayout);
            }

            _state.EndDispose();
        }

        private VkDescriptorPool CreateVulkanDescriptorPool()
        {
            VkDescriptorPool vulkanDescriptorPool = VK_NULL_HANDLE;
            var vulkanDescriptorPoolSizes = Array.Empty<VkDescriptorPoolSize>();

            var descriptorPoolCreateInfo = new VkDescriptorPoolCreateInfo {
                sType = VK_STRUCTURE_TYPE_DESCRIPTOR_POOL_CREATE_INFO,
                flags = (uint)VK_DESCRIPTOR_POOL_CREATE_FREE_DESCRIPTOR_SET_BIT,
                maxSets = 1,
            };

            var resources = Resources;
            var resourcesLength = resources.Length;

            if (resourcesLength != 0)
            {
                var vulkanDescriptorPoolSizesCount = 0;
                var constantBufferCount = 0;

                for (var resourceIndex = 0; resourceIndex < resourcesLength; resourceIndex++)
                {
                    var resource = resources[resourceIndex];

                    switch (resource.Kind)
                    {
                        case GraphicsPipelineResourceKind.ConstantBuffer:
                        {
                            if (constantBufferCount == 0)
                            {
                                vulkanDescriptorPoolSizesCount++;
                            }
                            constantBufferCount++;
                            break;
                        }

                        default:
                        {
                            break;
                        }
                    }
                }

                vulkanDescriptorPoolSizes = new VkDescriptorPoolSize[vulkanDescriptorPoolSizesCount];
                var vulkanDescriptorPoolSizesIndex = 0;

                if (constantBufferCount != 0)
                {
                    vulkanDescriptorPoolSizes[vulkanDescriptorPoolSizesIndex] = new VkDescriptorPoolSize {
                        type = VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER,
                        descriptorCount = unchecked((uint)constantBufferCount),
                    };
                    vulkanDescriptorPoolSizesIndex++;
                }

                fixed (VkDescriptorPoolSize* pVulkanDescriptorPoolSizes = vulkanDescriptorPoolSizes)
                {
                    descriptorPoolCreateInfo.poolSizeCount = unchecked((uint)vulkanDescriptorPoolSizes.Length);
                    descriptorPoolCreateInfo.pPoolSizes = pVulkanDescriptorPoolSizes;

                    ThrowExternalExceptionIfNotSuccess(nameof(vkCreateDescriptorPool), vkCreateDescriptorPool(VulkanGraphicsDevice.VulkanDevice, &descriptorPoolCreateInfo, pAllocator: null, (ulong*)&vulkanDescriptorPool));
                }
            }

            return vulkanDescriptorPool;
        }

        private VkDescriptorSet CreateVulkanDescriptorSet()
        {
            VkDescriptorSet vulkanDescriptorSet = VK_NULL_HANDLE;
            var vulkanDescriptorPool = VulkanDescriptorPool;

            if (vulkanDescriptorPool != VK_NULL_HANDLE)
            {

                var vulkanDescriptorSetLayout = VulkanDescriptorSetLayout;

                var descriptorSetAllocateInfo = new VkDescriptorSetAllocateInfo {
                    sType = VK_STRUCTURE_TYPE_DESCRIPTOR_SET_ALLOCATE_INFO,
                    descriptorPool = vulkanDescriptorPool,
                    descriptorSetCount = 1,
                    pSetLayouts = (ulong*)&vulkanDescriptorSetLayout,
                };
                ThrowExternalExceptionIfNotSuccess(nameof(vkAllocateDescriptorSets), vkAllocateDescriptorSets(VulkanGraphicsDevice.VulkanDevice, &descriptorSetAllocateInfo, (ulong*)&vulkanDescriptorSet));
            }

            return vulkanDescriptorSet;
        }

        private VkDescriptorSetLayout CreateVulkanDescriptorSetLayout()
        {
            VkDescriptorSetLayout vulkanDescriptorSetLayout;

            var descriptorSetLayoutBindings = Array.Empty<VkDescriptorSetLayoutBinding>();

            var descriptorSetLayoutCreateInfo = new VkDescriptorSetLayoutCreateInfo {
                sType = VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_CREATE_INFO,
            };

            var resources = Resources;
            var resourcesLength = resources.Length;

            var descriptorSetLayoutBindingsIndex = 0;

            if (resourcesLength != 0)
            {
                descriptorSetLayoutBindings = new VkDescriptorSetLayoutBinding[resourcesLength];

                for (var resourceIndex = 0; resourceIndex < resourcesLength; resourceIndex++)
                {
                    var resource = resources[resourceIndex];

                    switch (resource.Kind)
                    {
                        case GraphicsPipelineResourceKind.ConstantBuffer:
                        {
                            var stageFlags = GetVulkanShaderStageFlags(resource.ShaderVisibility);

                            descriptorSetLayoutBindings[descriptorSetLayoutBindingsIndex] = new VkDescriptorSetLayoutBinding {
                                binding = unchecked((uint)descriptorSetLayoutBindingsIndex),
                                descriptorType = VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER,
                                descriptorCount = 1,
                                stageFlags = stageFlags,
                            };

                            descriptorSetLayoutBindingsIndex++;
                            break;
                        }

                        default:
                        {
                            break;
                        }
                    }
                }

                fixed (VkDescriptorSetLayoutBinding* pDescriptorSetLayoutBindings = descriptorSetLayoutBindings)
                {
                    descriptorSetLayoutCreateInfo.bindingCount = unchecked((uint)descriptorSetLayoutBindings.Length);
                    descriptorSetLayoutCreateInfo.pBindings = pDescriptorSetLayoutBindings;

                    ThrowExternalExceptionIfNotSuccess(nameof(vkCreateDescriptorSetLayout), vkCreateDescriptorSetLayout(VulkanGraphicsDevice.VulkanDevice, &descriptorSetLayoutCreateInfo, pAllocator: null, (ulong*)&vulkanDescriptorSetLayout));
                }
            }
            else
            {
                vulkanDescriptorSetLayout = VK_NULL_HANDLE;
            }

            return vulkanDescriptorSetLayout;

            static uint GetVulkanShaderStageFlags(GraphicsShaderVisibility shaderVisibility)
            {
                var stageFlags = VK_SHADER_STAGE_ALL;

                if (shaderVisibility != GraphicsShaderVisibility.All)
                {
                    if (!shaderVisibility.HasFlag(GraphicsShaderVisibility.Vertex))
                    {
                        stageFlags &= ~VK_SHADER_STAGE_VERTEX_BIT;
                    }

                    if (!shaderVisibility.HasFlag(GraphicsShaderVisibility.Pixel))
                    {
                        stageFlags &= ~VK_SHADER_STAGE_FRAGMENT_BIT;
                    }
                }

                return (uint)stageFlags;
            }
        }

        private VkPipelineLayout CreateVulkanPipelineLayout()
        {
            VkPipelineLayout vulkanPipelineLayout;

            var pipelineLayoutCreateInfo = new VkPipelineLayoutCreateInfo {
                sType = VK_STRUCTURE_TYPE_PIPELINE_LAYOUT_CREATE_INFO
            };

            var descriptorSetLayout = VulkanDescriptorSetLayout;

            if (descriptorSetLayout != VK_NULL_HANDLE)
            {
                pipelineLayoutCreateInfo.setLayoutCount = 1;
                pipelineLayoutCreateInfo.pSetLayouts = (ulong*)&descriptorSetLayout;
            }

            ThrowExternalExceptionIfNotSuccess(nameof(vkCreatePipelineLayout), vkCreatePipelineLayout(VulkanGraphicsDevice.VulkanDevice, &pipelineLayoutCreateInfo, pAllocator: null, (ulong*)&vulkanPipelineLayout));

            return vulkanPipelineLayout;
        }

        private void DisposeVulkanDescriptorPool(VkDescriptorPool vulkanDescriptorPool)
        {
            if (vulkanDescriptorPool != VK_NULL_HANDLE)
            {
                vkDestroyDescriptorPool(VulkanGraphicsDevice.VulkanDevice, vulkanDescriptorPool, pAllocator: null);
            }
        }

        private void DisposeVulkanDescriptorSet(VkDescriptorSet vulkanDescriptorSet)
        {
            if (vulkanDescriptorSet != VK_NULL_HANDLE)
            {
                _ = vkFreeDescriptorSets(VulkanGraphicsDevice.VulkanDevice, VulkanDescriptorPool, 1, (ulong*)&vulkanDescriptorSet);
            }
        }

        private void DisposeVulkanDescriptorSetLayout(VkDescriptorSetLayout vulkanDescriptorSetLayout)
        {
            if (vulkanDescriptorSetLayout != VK_NULL_HANDLE)
            {
                vkDestroyDescriptorSetLayout(VulkanGraphicsDevice.VulkanDevice, vulkanDescriptorSetLayout, pAllocator: null);
            }
        }

        private void DisposeVulkanPipelineLayout(VkPipelineLayout vulkanPipelineLayout)
        {
            if (vulkanPipelineLayout != VK_NULL_HANDLE)
            {
                vkDestroyPipelineLayout(VulkanGraphicsDevice.VulkanDevice, vulkanPipelineLayout, pAllocator: null);
            }
        }

        private VkFormat GetInputElementFormat(Type type)
        {
            var inputElementFormat = VK_FORMAT_UNDEFINED;

            if (type == typeof(Vector2))
            {
                inputElementFormat = VK_FORMAT_R32G32_SFLOAT;
            }
            else if (type == typeof(Vector3))
            {
                inputElementFormat = VK_FORMAT_R32G32B32_SFLOAT;
            }
            else if (type == typeof(Vector4))
            {
                inputElementFormat = VK_FORMAT_R32G32B32A32_SFLOAT;
            }

            return inputElementFormat;
        }
    }
}
