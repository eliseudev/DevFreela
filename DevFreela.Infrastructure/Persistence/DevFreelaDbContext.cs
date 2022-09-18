using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            new Project("Meu Projeto ASPNET Core 1", "Minha Descrição de Projeto 1", 1, 1, 10000);
            new Project("Meu Projeto ASPNET Core 2", "Minha Descrição de Projeto 2", 1, 1, 20000);
            new Project("Meu Projeto ASPNET Core 3", "Minha Descrição de Projeto 3", 1, 1, 30000);

            Users = new List<User>
            {
                new User("Eliseu Oliveira", "eliseu.dev@outlook.com", new DateTime(1989, 08, 31)),
                new User("Elias Ataides", "elias.dev@outlook.com", new DateTime(2018, 05, 10)),
                new User("Allana Ataides", "allana.dev@outlook.com", new DateTime(1986, 05, 10)),
            };

            Skills = new List<Skill>
            {
                  new Skill(".Net Core"),
                  new Skill("C#"),
                  new Skill("SQL")
            };

        }
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }
    }
}
