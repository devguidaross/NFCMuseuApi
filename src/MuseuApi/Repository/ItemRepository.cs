using System;
using System.Linq;
using MuseuApi.Entities;
using MuseuApi.Models;
using Newtonsoft.Json;

namespace MuseuApi.Repository
{
    public static class ItemRepository
    {
        public static ResponsePadrao NovoItem(Item item)
        {
            try
            {
                Console.WriteLine($"item: {JsonConvert.SerializeObject(item)}");
                var mensagem = item.Id > 0 ? "alterado" : "inserido";
                Console.WriteLine($"lMensagem: {mensagem}");
                
                Console.WriteLine("Antes");
                var itemEncontrado = Startup.MuseuContext.Item.FirstOrDefault(f => f.Id == item.Id);
                if (itemEncontrado != null)
                {
                    itemEncontrado.Ativo = item.Ativo;
                    itemEncontrado.Descricao = item.Descricao;
                    itemEncontrado.Familia = item.Familia;
                    itemEncontrado.Habitat = item.Habitat;
                    itemEncontrado.Nome = item.Nome;
                    itemEncontrado.Ordem = item.Ordem;
                    itemEncontrado.Reproducao = item.Reproducao;
                    itemEncontrado.DistribuicaoGeografica = item.DistribuicaoGeografica;
                    itemEncontrado.HabitosAlimentares = item.HabitosAlimentares;
                    itemEncontrado.PeriodoDeVida = item.PeriodoDeVida;
                    Startup.MuseuContext.Item.Update(itemEncontrado);   
                }
                else
                {
                    item.DataCadastro = DateTime.Now;
                    Startup.MuseuContext.Item.Add(item);  
                } 
                
                Console.WriteLine("Depois");
                
                Startup.MuseuContext.SaveChanges();
                
                Console.WriteLine("Salvou");
                
                return new ResponsePadrao()
                {
                    Sucesso = true,
                    Codigo = item.Id,
                    Data = item,
                    Mensagem = $"Item {mensagem} com sucesso"
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ResponsePadrao()
                {
                    Sucesso = false,
                    Mensagem = e.Message
                }; 
            }
        }
    }
}