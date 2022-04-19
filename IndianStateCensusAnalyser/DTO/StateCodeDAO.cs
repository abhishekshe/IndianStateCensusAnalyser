using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser.POCO
{
    public class StateCodeDAO
    {
        public string stateName;
        public string stateCode;
        public int tin;
        public int serialNumber;


        public StateCodeDAO(string v1, string v2, string v3, string v4)
        {
            this.stateName = v2;
            this.stateCode = v4;
            this.tin = Convert.ToInt32(v3);
            this.serialNumber = Convert.ToInt32(v1);
        }
    }


}