﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal interface IHandler
    {
        void AddVehicle();
        void DisplayVehicles();
        void RemoveVehicle();
        void DisplayGarageSize();
        void SearchVehicleByRegNbr();
        void SearchByProperties();

    }
}
