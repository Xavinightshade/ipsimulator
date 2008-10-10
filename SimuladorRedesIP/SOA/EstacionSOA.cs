using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RedesIP.SOA
{
    [DataContract]
    public class EstacionSOA
    {
        private List<ComputadorSOA> _computadores=new List<ComputadorSOA>();
        [DataMember]
        public List<ComputadorSOA> Computadores
        {
            get { return _computadores; }
            set { _computadores = value; }
        }

        private List<SwitchSOA> _switches=new List<SwitchSOA>();
        [DataMember]
        public List<SwitchSOA> Switches
        {
            get { return _switches; }
            set { _switches = value; }
        }
        private List<SwitchVLanSOA> _switchesVlan = new List<SwitchVLanSOA>();
        [DataMember]
        public List<SwitchVLanSOA> SwitchesVLan
        {
            get { return _switchesVlan; }
            set { _switchesVlan = value; }
        }
        private List<RouterSOA> _routers=new List<RouterSOA>();
        [DataMember]
        public List<RouterSOA> Routers
        {
            get { return _routers; }
            set { _routers = value; }
        }
        private List<CableSOA> _cables=new List<CableSOA>();
        [DataMember]
        public List<CableSOA> Cables
        {
            get { return _cables; }
            set { _cables = value; }
        }
    }
}
