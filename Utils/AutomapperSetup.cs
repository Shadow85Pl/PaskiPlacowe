using AutoMapper;
using Microsoft.Win32;
using PaskiPlacowe.InteractionRequest;
using PaskiPlacowe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaskiPlacowe.Utils
{
    internal class AutomapperSetup
    {
        public static void AutomapperInitialize()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<OpenFileDialogConfirmation, OpenFileDialog>();
                cfg.CreateMap< SL_TYPOW_POL_PP, PaskiPlacowe_POZ> ().ReverseMap();
                cfg.CreateMap<SalarySlipPozLJ, PaskiPlacowe_POZ>().ConstructUsing(SSPLJToPPPConverter);
                cfg.CreateMap<PaskiPlacowe_POZ, Int64>();
            });
        }

        private static PaskiPlacowe_POZ SSPLJToPPPConverter(SalarySlipPozLJ arg)
        {
            var tmp = Mapper.Map<PaskiPlacowe_POZ>(arg.SPOZ);
            //return arg.POZ ?? tmp;
            return tmp;
        }

    }
}
