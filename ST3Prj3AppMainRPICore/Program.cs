using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ST3PRJ3PresentationLogicCoreRPI.Boundaries;
using ST3Prj3BusinessLogicCore.Controller; //Her findes den konkrete implementation af BL
using ST3Prj3DataAccessLogicCore.Boundaries; //Her findes den konkrete implementation af DAL
using ST3Prj3InterfacesCore; //Her er kontrakter/interfaces defineret

namespace ST3Prj3AppMainCore
{
    class Program
    {

        //Brug Interface referencer  
        //Alle objekter der er globalt brug og brugt mellem Logiklag opsættes her
        //Her kan overvejes en global systemdatamodel som så injectes i den forskellige lag
        private iPresentationLogic icurrentGUIPL;     
        private iBusinessLogic icurrentBL;       
        private iDataAccessLogic icurrentDAL;

        static void Main(string[] args)
        {
            _ = new Program();
        }

        public Program()
        {
                       
            //Opsætning af referencer til implementationer af interfaces 
            icurrentDAL = new CtrlDataAccessLogic(); 
            icurrentBL = new CtrlBusinessLogic(icurrentDAL);
            icurrentGUIPL = new  SimpelCtrlRPIUI(icurrentBL);
            //Eller omstil til en anden for UI (User Interface)
            //icurrentGUIPL = new AnotherGUI(icurrentBL); 
            icurrentGUIPL.startUpGUI();//Trin start applikation

        }
    }
}
