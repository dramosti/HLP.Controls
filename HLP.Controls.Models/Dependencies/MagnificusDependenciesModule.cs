using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Models.Dependencies
{
    public class MagnificusDependenciesModule : NinjectModule
    {
        public override void Load()
        {
            this.ResolveRepositories();
        }

        protected void ResolveRepositories()
        {
        }
    }
}
