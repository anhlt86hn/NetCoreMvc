using Microsoft.AspNetCore.Identity;
using NetCoreMvc.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvc.WebApp
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly string AdminRoleName = "Admin";
        private readonly string UserRoleName = "Member";

        public DbInitializer(AppDbContext context,
         UserManager<AppUser> userManager,
         RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            #region Quyền

            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new AppRole
                {
                    Id = AdminRoleName,
                    Name = AdminRoleName,
                    NormalizedName = AdminRoleName.ToUpper(),
                });
                await _roleManager.CreateAsync(new AppRole
                {
                    Id = UserRoleName,
                    Name = UserRoleName,
                    NormalizedName = UserRoleName.ToUpper(),
                });
            }

            #endregion Quyền

            #region Người dùng

            if (!_userManager.Users.Any())
            {
                var result = await _userManager.CreateAsync(new AppUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "rico",
                    Email = "luonganh@gmail.com",
                    FirstName = "Tuan Anh",
                    LastName = "Luong",
                    LockoutEnabled = false
                }, "Admin@123");
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync("rico");
                    await _userManager.AddToRoleAsync(user, AdminRoleName);
                }
            }

            #endregion Người dùng

            #region Chức năng

            if (!_context.Functions.Any())
            {
                _context.Functions.AddRange(new List<Function>
                {
                    new Function {Id = "DASHBOARD", Name = "Thống kê", Status = Enums.Status.Active, ParentId = null, SortOrder = 1,Url = "/Admin/Dashboard",Icon="fa-dashboard" },

                    new Function {Id = "CONTENT",Name = "Nội dung",Status = Enums.Status.Active, ParentId = null,Url = "/Admin/Contents",Icon="fa-table" },

                    new Function {Id = "CONTENT_CATEGORY",Name = "Danh mục", Status = Enums.Status.Active, ParentId ="CONTENT",Url = "/Admin/Categories",Icon="fa-folder-open" },
                    new Function {Id = "CONTENT_POST",Name = "Bài viết", Status = Enums.Status.Active, ParentId = "CONTENT",SortOrder = 2,Url = "/Admin/Posts",Icon="fa-book" },

                    new Function {Id = "SYSTEM", Name = "Hệ thống", Status = Enums.Status.Active, ParentId = null, Url = "/Admin/Systems",Icon="fa-th-list" },

                    new Function {Id = "SYSTEM_USER", Name = "Người dùng", Status = Enums.Status.Active, ParentId = "SYSTEM",Url = "/Admin/Users",Icon="fa-user"},
                    new Function {Id = "SYSTEM_ROLE", Name = "Nhóm quyền", Status = Enums.Status.Active, ParentId = "SYSTEM",Url = "/Admin/Roles",Icon="fa-user-o"},
                    new Function {Id = "SYSTEM_FUNCTION", Name = "Chức năng", Status = Enums.Status.Active, ParentId = "SYSTEM",Url = "/Admin/Functions",Icon="fa-list"},
                    new Function {Id = "SYSTEM_PERMISSION", Name = "Quyền hạn", Status = Enums.Status.Active, ParentId = "SYSTEM",Url = "/Admin/Permissions",Icon="fa-desktop"},
                });
                await _context.SaveChangesAsync();
            }

            if (!_context.Commands.Any())
            {
                _context.Commands.AddRange(new List<Command>()
                {
                    new Command(){Id = "EXPORT", Name = "Xuất"},
                    new Command(){Id = "IMPORT", Name = "Nhập"},
                    new Command(){Id = "VIEW", Name = "Xem"},
                    new Command(){Id = "CREATE", Name = "Thêm"},
                    new Command(){Id = "UPDATE", Name = "Sửa"},
                    new Command(){Id = "DELETE", Name = "Xoá"},
                    new Command(){Id = "APPROVE", Name = "Duyệt"},
                });
            }

            #endregion Chức năng

            var functions = _context.Functions;

            if (!_context.CommandInFunctions.Any())
            {
                foreach (var function in functions)
                {
                    var approveAction = new CommandInFunction()
                    {
                        CommandId = "APPROVE",
                        FunctionId = function.Id
                    };
                    _context.CommandInFunctions.Add(approveAction);

                    var createAction = new CommandInFunction()
                    {
                        CommandId = "CREATE",
                        FunctionId = function.Id
                    };
                    _context.CommandInFunctions.Add(createAction);

                    var updateAction = new CommandInFunction()
                    {
                        CommandId = "UPDATE",
                        FunctionId = function.Id
                    };
                    _context.CommandInFunctions.Add(updateAction);

                    var deleteAction = new CommandInFunction()
                    {
                        CommandId = "DELETE",
                        FunctionId = function.Id
                    };
                    _context.CommandInFunctions.Add(deleteAction);

                    var viewAction = new CommandInFunction()
                    {
                        CommandId = "VIEW",
                        FunctionId = function.Id
                    };
                    _context.CommandInFunctions.Add(viewAction);

                    var importAction = new CommandInFunction()
                    {
                        CommandId = "IMPORT",
                        FunctionId = function.Id
                    };
                    _context.CommandInFunctions.Add(importAction);

                    var exportAction = new CommandInFunction()
                    {
                        CommandId = "EXPORT",
                        FunctionId = function.Id
                    };
                    _context.CommandInFunctions.Add(exportAction);
                }
            }

            if (!_context.Permissions.Any())
            {
                var adminRole = await _roleManager.FindByNameAsync(AdminRoleName);
                foreach (var function in functions)
                {
                    _context.Permissions.Add(new Permission(function.Id, adminRole.Id, "APPROVE"));
                    _context.Permissions.Add(new Permission(function.Id, adminRole.Id, "CREATE"));
                    _context.Permissions.Add(new Permission(function.Id, adminRole.Id, "UPDATE"));
                    _context.Permissions.Add(new Permission(function.Id, adminRole.Id, "DELETE"));
                    _context.Permissions.Add(new Permission(function.Id, adminRole.Id, "VIEW"));
                    _context.Permissions.Add(new Permission(function.Id, adminRole.Id, "IMPORT"));
                    _context.Permissions.Add(new Permission(function.Id, adminRole.Id, "EXPORT"));
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}