using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IcarusNetFrontend_Winforms
{
    public interface IProjectComponentForm
    {
        void Initialize(IcarusNetProject.Components.Component component);
        IcarusNetProject.Components.Component GetComponent();
    }
}
