﻿using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
    public class ControladorAluguel : ControladorBase<Aluguel, RepositorioAluguel, ServicoAluguel, TabelaAluguelControl, TelaAluguelForm, NoService, NoService>
    {
        public ControladorAluguel(RepositorioAluguel _repositorio, ServicoAluguel _servico, TabelaAluguelControl _tabela) : base(_repositorio, _servico, _tabela)
        {
            OnComandosAdicionaisAddAndEdit += ObterDependencias;
        }

        protected override string TipoCadastro => "Aluguéis";

        private void ObterDependencias(TelaAluguelForm tela, Aluguel aluguel)
        {
            _servico.servicoFuncionario.SelecionarTodosOsRegistros();
            _servico.servicoCliente.SelecionarTodosOsRegistros();
            _servico.servicoCategoriaAutomoveis.SelecionarTodosOsRegistros();
            _servico.servicoPlanosCobrancas.SelecionarTodosOsRegistros();
            _servico.servicoCondutores.SelecionarTodosOsRegistros();
            _servico.servicoAutomovel.SelecionarTodosOsRegistros();
            _servico.servicoCupom.SelecionarTodosOsRegistros();
            _servico.servicoTaxaEServico.SelecionarTodosOsRegistros();
        }
    }
}