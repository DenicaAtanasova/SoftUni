﻿namespace P03_BarraksWars.Core.Commands
{
    using _03BarracksFactory.Contracts;

    public abstract class Command : IExecutable
    {
        private string[] data;

        public Command(string[] data)
        {
            this.Data = data;
        }
        
        public string[] Data { get; private set; }

        public abstract string Execute();
    }
}