namespace secondogiorno
{
    public class CV
    {
        public personalInfo personalInfo { get; set; }= new personalInfo();
        public List<TitoloDiStudio> Studio { get; set; }=new List<TitoloDiStudio>();
        public List<Esperienza> Impiego {  get; set; } =new List<Esperienza>();
    }
}
