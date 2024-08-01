namespace chatbot_backend.ViewModels

    {
    public class VecozoResult
    {
        public VecozoResultType ResultType { get; set; }
        public VecozoResultType ResultDetailType { get; set; }
        public VecozoInsuree Insurer { get; set; }
    }
    public enum VecozoResultType
    {
        GeenZoekopdrachten = 0,

        MeerDan20Zoekopdrachten = 1,

        VerzoekAkkoord = 2,
    }
    public class VecozoInsuree
    {
        public int FiscalNumber { get; set; }
        public string PatientNumber { get; set; }
        public System.DateTime Birthdate { get; set; }
        public VecozoGender Gender { get; set; }
        public string Lastname { get; set; }
        public string Initals { get; set; }
        public string Lastname2 { get; set; }
        public string Prefix2 { get; set; }
        public string Perfix { get; set; }
        public bool Deceased { get; set; }
        public VecozoInsureeResultType Result { get; set; }
        public List<VecozoInsurance> Insurances { get; set; }
    }
    public enum VecozoInsureeResultType
    {
        ActieveVerzekeringen = 0,

        DubbeleActieveVerzekeringenGevonden = 1,

        InactieveVerzekeringen = 2,
    }

    public enum VecozoGender
    {
        Man = 0,

        Vrouw = 1,

        Onbekend = 2,

        NietGespecificeerd = 3,
    }

    public class VecozoInsurance
    {
        public int InsurerNumber { get; set; }
        public string InsureeNumber { get; set; }
        public VecozoInsuranceType InsuranceType { get; set; }
        public string InsurancePackageCode { get; set; }
        public string InsurancePackageName { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime? EndDate { get; set; }
        public VecozoInsuranceResultType Result { get; set; }
        public InsuranceStatus Status { get; set; }
    }
    public enum VecozoInsuranceType
    {
        Aanvullend = 0,
        AanvullendPlusTand = 1,
        AWBZ = 2,
        Basis = 3,
        Hoofdverzekering = 4,
        Tand = 5,
    }

    public enum InsuranceStatus
    {
        StillToBeChecked = 0,
        NotApplicable = 1,
        NotOk = 2,
        OK = 3,
        HelpBeforeCheck = 4
    }
    public enum VecozoInsuranceResultType
    {
        Actief = 0,

        Inactief = 1,

        NietGeautoriseerdVoorZorgverzekeraar = 2,
    }
    public class VecozoSearchCriteriaVM
    {
        public string InsureeNumber { get; set; }
        public int InsurerNumber { get; set; }
        public string Patientnumber { get; set; }
        public DateTime Birthdate { get; set; }
        public string Lastname { get; set; }
        public string PostalCode { get; set; }
        public int HouseNumber { get; set; }
        public string HouseNumberLetter { get; set; }
        public DateTime InsuranceReferenceDate { get; set; }
    }
}

