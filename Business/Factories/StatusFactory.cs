using Business.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Factories;

public static class StatusFactory
{
    public static Status? Create(StatusEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        var status = new Status()
        {
            Id = entity.Id,
            StatusName = entity.StatusName,
            Projects = new List<Project>()
        };

        if (entity.Projects != null)
        {
            var projects = new List<Project>();
            foreach (var project in entity.Projects)
                projects.Add(new Project
                {
                    Id = project.Id,
                    Description = project.Description,
                });

            status.Projects = projects;
        }

        return status;
    }

}
