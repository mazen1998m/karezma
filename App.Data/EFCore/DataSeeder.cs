using App.Domain.Users;
using App.Domain.Users.Permissions;
using App.Domain.Users.RolePermissions;
using App.Domain.Users.Roles;
using App.Domain.Users.UserRoles;
using Microsoft.EntityFrameworkCore;
using Muslim.Assembly.Helper;
using System.Data;

namespace App.Data.EFCore;

public class DataSeeder<TYpeContext>
where TYpeContext : DbContext
{
    private readonly TYpeContext _context;

    private DbSet<User> Users { get; set; }
    private DbSet<Role> Roles { get; set; }
    private DbSet<RolePermission> RolePermission { get; set; }

    private DbSet<Permission> Permission { get; set; }

    private DbSet<UserRole> UserRole { get; set; }

    private readonly DateTime date = DateTime.Now;
    public DataSeeder(TYpeContext context)
    {
        _context = context;
        Users = context.Set<User>();
        Roles = context.Set<Role>();
        RolePermission = context.Set<RolePermission>();
        UserRole = context.Set<UserRole>();
        Permission = context.Set<Permission>();
    }

    //public async Task SeedDataAsync()
    //{

    //    // Check if data already exists
    //    if (!Users.Any())
    //    {
    //        if (!Roles.Any())
    //        {
    //            Roles.AddRange(new List<Role>
    //            {
    //                new ()
    //                {
    //                    CreatedDate = DateTime.Now,
    //                    Name = RolesName.SuperAdmin.ToString(),
    //                    IsActive = true,
    //                    CreatedBy = "System",
    //                },
    //                new ()
    //                {
    //                    CreatedDate = DateTime.Now,
    //                    Name = RolesName.TeamLeader.ToString(),
    //                    IsActive = true,
    //                    CreatedBy = "System",
    //                },
    //                new ()
    //                {
    //                    CreatedDate = DateTime.Now,
    //                    Name = RolesName.Customer.ToString(),
    //                    IsActive = true,
    //                    CreatedBy = "System",
    //                },
    //                new ()
    //                {
    //                    CreatedDate = DateTime.Now,
    //                    Name = RolesName.Employee.ToString(),
    //                    IsActive = true,
    //                    CreatedBy = "System",
    //                },
    //                new ()
    //                {
    //                    Name = "Developer",
    //                    CreatedDate = date,
    //                    IsActive = true,
    //                    CreatedBy = "System",
    //                }
    //        });
    //            await _context.SaveChangesAsync();
    //        }

    //        var developerRole = Roles.FirstOrDefault(x => x.Name == "Developer");

    //        var permissions = GetPermissions();

    //        Permission.AddRange(permissions);
    //        await _context.SaveChangesAsync();



    //        var rolePermissions = permissions.Select(permission => new RolePermission
    //        {
    //            RoleId = developerRole!.Id,
    //            PermissionId = permission.Id,
    //            CreatedDate = date,
    //            CreatedBy = "System"
    //        }).ToList();


    //        RolePermission.AddRange(rolePermissions);
    //        await _context.SaveChangesAsync();



    //        var user = new User
    //        {
    //            Name = "Developer",
    //            Phone = "1234567890",
    //            UserType = UserType.Developer,
    //            Email = "mazen1998m@live.com",
    //            Password = "P@ssw0rd".ComputeSha256Hash(),
    //            CreatedDate = date,
    //            CreatedBy = "System",
    //            IsActive = true

    //        };
    //        Users.Add(user);
    //        await _context.SaveChangesAsync();

    //        var userDeveloper = Users.FirstOrDefault(x => x.Name == "Developer");
    //        var userRole = new UserRole
    //        {
    //            UserId = userDeveloper!.Id,
    //            RoleId = developerRole!.Id,
    //            CreatedDate = date,
    //            CreatedBy = "System"
    //        };
    //        UserRole.Add(userRole);
    //        await _context.SaveChangesAsync();

    //    }


    //}



    public async Task SeedDataAsync()
    {
        // Check if data already exists
        //if (!Users.Any())
        //{
        //    var date = DateTime.Now;
        //    var user = new User
        //    {
        //        Name = "Developer",
        //        Phone = "1234567890",
        //        UserType = UserType.Developer,
        //        Email = "mazen1998m@live.com",
        //        Password = "P@ssw0rd".ComputeSha256Hash(),
        //        CreatedDate = date,
        //        CreatedBy = "System",
        //        IsActive = true,
        //    };
        //    var role = new Role
        //    {
        //        Name = "Developer",
        //        IsActive = true,
        //        CreatedDate = date,
        //        CreatedBy = "System",
        //    };


        //    UserRole.Add(new UserRole
        //    {
        //        User = user,
        //        Role = role,
        //        CreatedDate = date,
        //        CreatedBy = "System",
        //    });

        //    await _context.SaveChangesAsync();


        //    // Seed Permission and RolePermission data
        //    var controllers = AssemblyHelper.GeTypesByName(AssemblyHelper.GetAssembly("app.Dashboard"), "Controller")
        //            .Where(t => t.Namespace!.StartsWith("App.Dashboard.Controllers") && !t.Name.StartsWith("<"))
        //        ;

        //    var rolePermissions = new List<RolePermission>();

        //    var developerRole = Roles.FirstOrDefault(r => r.Name == "Developer");
        //    foreach (var controller in controllers)
        //    {

        //        var actions =
        //        (
        //            from method in controller.GetMethods()
        //            where !method.IsSpecialName && method.DeclaringType == controller
        //            select method
        //        ).Distinct().ToList();



        //        foreach (var action in actions)
        //        {
        //            var endpointName = $"{controller.Name.Replace("Controller", "")}.{action.Name}";
        //            var permission = new Permission
        //            {
        //                Name = endpointName,
        //                EndPointName = endpointName,
        //                CreatedDate = date,
        //                CreatedBy = "System",

        //            };

        //            var rolePermission = new RolePermission
        //            {
        //                Permission = permission,
        //                Role = role,
        //                CreatedDate = date,
        //                CreatedBy = "System",
        //            };
        //            rolePermissions.Add(rolePermission);
        //        }
        //    }

        //    RolePermission.AddRange(rolePermissions);

        //    await _context.SaveChangesAsync();
        //}

        //if (!Roles.Any())
        //{
        //    Roles.AddRange(new List<Role>
        //    {
        //        new Role()
        //        {
        //            CreatedDate = DateTime.Now,
        //            Name = SystemRole.SuperAdmin.ToString()
        //        },
        //        new Role()
        //        {
        //            CreatedDate = DateTime.Now,
        //            Name = SystemRole.TeamLeader.ToString()
        //        },

        //        new Role()
        //        {
        //            CreatedDate = DateTime.Now,
        //            Name = SystemRole.Customer.ToString()
        //        },
        //        new Role()
        //        {
        //            CreatedDate = DateTime.Now,
        //            Name = SystemRole.Employee.ToString()
        //        }
        //    });
        //    await _context.SaveChangesAsync();
        //}
    }

    public List<Permission> GetPermissions()
    {
        var permissions = new List<Permission>();
        var controllers = AssemblyHelper.GeTypesByName(AssemblyHelper.GetAssembly("app.Dashboard"), "Controller")
                    .Where(t => t.Namespace!.StartsWith("App.Dashboard.Controllers") && !t.Name.StartsWith("<"));
        foreach (var controller in controllers)
        {



            var actions = controller.GetMethods()
                .Where(method => !method.IsSpecialName && method.DeclaringType == controller)
                .ToList();


            permissions.AddRange(actions.Select(action => new Permission
            {
                Name = $"{action.Name} {controller.Name.Replace("Controller", "")}",
                EndPointName = $"{controller.Name.Replace("Controller", "")}.{action.Name}",
                CreatedDate = date,
                CreatedBy = "System"
            }).DistinctBy(p => new { p.Name, p.EndPointName }).ToList());

        }
        return permissions;

    }

}



public class DataSeeder2<TYpeContext>
where TYpeContext : DbContext
{
    private readonly TYpeContext _context;

    private DbSet<User> Users { get; set; }
    private DbSet<Role> Roles { get; set; }
    private DbSet<UserRole> UserRoles { get; set; }
    private DbSet<Permission> Permissions { get; set; }
    private DbSet<RolePermission> RolePermissions { get; set; }

    public DataSeeder2(TYpeContext context)
    {
        _context = context;
        Users = context.Set<User>();
        Roles = context.Set<Role>();
        UserRoles = context.Set<UserRole>();
        Permissions = context.Set<Permission>();
        RolePermissions = context.Set<RolePermission>();
    }

    public async Task SeedDataAsync()
    {
        // Check if data already exists
        //if (!Users.Any())
        //{
        //    var date = DateTime.Now;
        //    var user = new User
        //    {
        //        Name = "Developer",
        //        Phone = "1234567890",
        //        UserType = UserType.Developer,
        //        Email = "mazen1998m@live.com",
        //        Password = "P@ssw0rd".ComputeSha256Hash(),
        //        CreatedDate = date,
        //        CreatedBy = "System",
        //        IsActive = true,
        //    };
        //    var role = new Role
        //    {
        //        Name = "Developer",
        //        IsActive = true,
        //        CreatedDate = date,
        //        CreatedBy = "System",
        //    };


        //    UserRoles.Add(new UserRole
        //    {
        //        User = user,
        //        Role = role,
        //        CreatedDate = date,
        //        CreatedBy = "System",
        //    });

        //    await _context.SaveChangesAsync();


        //    // Seed Permission and RolePermission data
        //    var controllers = AssemblyHelper.GeTypesByName(AssemblyHelper.GetAssembly("app.Dashboard"), "Controller")
        //            .Where(t => t.Namespace!.StartsWith("App.Dashboard.Controllers") && !t.Name.StartsWith("<"))
        //        ;

        //    var rolePermissions = new List<RolePermission>();

        //    var developerRole = Roles.FirstOrDefault(r => r.Name == "Developer");
        //    foreach (var controller in controllers)
        //    {

        //        var actions =
        //        (
        //            from method in controller.GetMethods()
        //            where !method.IsSpecialName && method.DeclaringType == controller
        //            select method
        //        ).Distinct().ToList();



        //        foreach (var action in actions)
        //        {
        //            var endpointName = $"{controller.Name.Replace("Controller", "")}.{action.Name}";
        //            var permission = new Permission
        //            {
        //                Name = endpointName,
        //                EndPointName = endpointName,
        //                CreatedDate = date,
        //                CreatedBy = "System",

        //            };

        //            var rolePermission = new RolePermission
        //            {
        //                Permission = permission,
        //                Role = role,
        //                CreatedDate = date,
        //                CreatedBy = "System",
        //            };
        //            rolePermissions.Add(rolePermission);
        //        }
        //    }

        //    RolePermissions.AddRange(rolePermissions);

        //    await _context.SaveChangesAsync();
        //}

        //if (!Roles.Any())
        //{
        //    Roles.AddRange(new List<Role>
        //    {
        //        new Role()
        //        {
        //            CreatedDate = DateTime.Now,
        //            Name = SystemRole.SuperAdmin.ToString()
        //        },
        //        new Role()
        //        {
        //            CreatedDate = DateTime.Now,
        //            Name = SystemRole.TeamLeader.ToString()
        //        },

        //        new Role()
        //        {
        //            CreatedDate = DateTime.Now,
        //            Name = SystemRole.Customer.ToString()
        //        },
        //        new Role()
        //        {
        //            CreatedDate = DateTime.Now,
        //            Name = SystemRole.Employee.ToString()
        //        }
        //    });
        //    await _context.SaveChangesAsync();
        //}
    }
}