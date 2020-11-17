namespace PeatHotel.Models
{
    public class Hospedagem
    {
        public int hospedagemId { get; set; }
        public int hospedagemTipoId { get; set; }
        public HospedagemTipo hospedagemTipo { get; set; }
        public int peatId { get; set; }
        public Peat peat { get; set; }
        public int clienteId { get; set; }
        public Cliente cliente { get; set; }
        public int servicoId { get; set; }
        public Servico servico { get; set; }

    }
}