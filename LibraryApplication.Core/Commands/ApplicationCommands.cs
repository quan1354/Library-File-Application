using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieApplication.Core.Commands
{
    public interface IApplicationCommands { 
        CompositeCommand refreshCommand { get; }
    }
    public class ApplicationCommands : IApplicationCommands
    {
        public CompositeCommand refreshCommand { get; } = new CompositeCommand();
    }
}
