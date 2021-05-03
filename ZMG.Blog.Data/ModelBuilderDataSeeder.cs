using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZMG.Blog.Core.Models;

namespace ZMG.Blog.Data
{
    [ExcludeFromCodeCoverage]
    public static class ModelBuilderDataSeeder
    {
        /// <summary>
        /// Populates the database with some initial data
        /// </summary>
        /// <param name="builder">Model builder object</param>
        public static void DataSeed(this ModelBuilder builder)
        {
            // populate customer type.
            builder.Entity<PostState>()
                .HasData(
                    new { Id = Guid.Parse("1789874c-545c-4d88-a5c0-fc0cbdb3d7b7"), Name = "New", ResourceKey = "POSTSTATE_NEW" },
                    new { Id = Guid.Parse("42c5ca83-7e99-43fe-9880-a24a97584e43"), Name = "Pending Publish Approval", ResourceKey = "POSTSTATE_PENDING_PUBLISH_APPROVAL" },
                    new { Id = Guid.Parse("58f1b3a5-f4c4-4a95-947b-670c8e7e5bf0"), Name = "Published", ResourceKey = "POSTSTATE_PUBLISHED" },
                    new { Id = Guid.Parse("e41cff8c-9ef9-45bd-ac74-fbb8b84a7ae5"), Name = "Delete", ResourceKey = "POSTSTATE_DELETE" }
                );
        }
        }
    }
