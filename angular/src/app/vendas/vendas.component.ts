import { Component, OnInit } from '@angular/core';
import axios from 'axios';

@Component({
  selector: 'app-vendas',
  templateUrl: './vendas.component.html',
  styleUrls: ['./vendas.component.css']
})
export class VendasComponent implements OnInit {


   
  vendas: any = [];
  rascunho: any = {
    id: 0,
    ordem: "",
    quantidade: 0,
    total: 0,
    status: "",
    produto: {
      id: 0,
      nome: "",
      descricao: "",
      preco: 0,
      estoque: 0
    },
    usuario: {
      id: 0,
      nome: "",
      email: ""
    }
  };
  selecionado: any = null;
  acao = "";
  constructor() {

  }

  ngOnInit(): void {
    this.buscar();
  }
  limparRascunho() {
    this.rascunho = {
      id: 0,
      ordem: "",
      quantidade: 0,
      total: 0,
      status: "",
      produto: {
        id: 0,
        nome: "",
        descricao: "",
        preco: 0,
        estoque: 0
      },
      usuario: {
        id: 0,
        nome: "",
        email: ""
      }
    };

  }
  async buscar() {
    axios.get("https://localhost:44389/" + "api/Venda")
      .then(res => {
        this.vendas = JSON.parse(JSON.stringify(res.data));
      })
      .catch(err => {
        console.log(err);
      });
  }

  atualizar() {

      let valid = confirm("Deseja atualizar?");
      if (valid) {
        axios.put("https://localhost:44389/" + "api/Venda", JSON.stringify(this.selecionado), { headers: { 'Content-Type': 'application/json' } })
          .then(res => {
            alert("salvo")
            this.buscar();
            this.selecionado = null; 
            this.acao = '';
          })
          .catch(err => {
            console.log(err);
          });
      }
    
  }

}
