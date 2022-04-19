//using IndianStateCensusAnalyser.Constructor_for_different_CSV;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser.POCO
{
    public class CensusDTO
    {
        public int serialNumber;
        public string stateName;
        public long population;
        public long area;
        public long density;
        public string state;
        public string stateCode;
        public int tin;
        public long housingUnits;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double populationDensity;
        public double housingDensity;



        public CensusDTO(StateCodeDAO StateCodeDao)
        {
            this.serialNumber = StateCodeDao.serialNumber;
            this.stateName = StateCodeDao.stateName;
            this.tin = StateCodeDao.tin;
            this.stateCode = StateCodeDao.stateCode;
        }

        public CensusDTO(CensusDataDAO censusDataDao)
        {
            this.state = censusDataDao.state;
            this.population = censusDataDao.population;
            this.area = censusDataDao.area;
            this.density = censusDataDao.density;
        }


    }
}