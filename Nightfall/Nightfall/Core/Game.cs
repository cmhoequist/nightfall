using Nightfall.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nightfall.Core
{
    public class Game
    {
        private string _name;
        public int Id { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ValidationException("Must provide a Game Name");
                }
                _name = value;
            }
        }

        private Game() { }

        public Game(string name)
        {
            Name = name;
        }

        public static Game Reconstitute(int id, string name)
        {
            return new Game()
            {
                Id = id,
                Name = name
            };
        }
    }
}
