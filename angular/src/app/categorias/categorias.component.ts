import { Component, OnInit } from '@angular/core';
import axios from 'axios';

@Component({
  selector: 'app-categorias',
  templateUrl: './categorias.component.html',
  styleUrls: ['./categorias.component.css']
})
export class CategoriasComponent implements OnInit {

 
  categorias: any = [];
  rascunho: any = {
    nome: "",
    descricao: "",
    produtos: []
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
      nome: "",
      descricao: "",
      produtos: []
    };

  }
  async buscar() {
    axios.get("https://localhost:44389/" + "api/Categoria")
      .then(res => {
        this.categorias = JSON.parse(JSON.stringify(res.data));
      })
      .catch(err => {
        console.log(err);
      });
  }

  adicionar() {
    if (this.rascunho.nome != "" && this.rascunho.descricao != "") {
      let valid = confirm("Deseja adicionar?");
      if (valid) {
        axios.post("https://localhost:44389/" + "api/Categoria", JSON.stringify(this.rascunho), { headers: { 'Content-Type': 'application/json' } })
          .then(res => {
            alert("salvo")
            this.buscar();
            this.limparRascunho(); 
            this.acao = '';
          })
          .catch(err => {
            console.log(err);
          });
      }
    } else {
      alert("Preencha todos os campos");
    }
  }
  
  atualizar() {
    if (this.selecionado.nome != "" && this.selecionado.descricao != "") {
      let valid = confirm("Deseja atualizar?");
      if (valid) {
        axios.put("https://localhost:44389/" + "api/Categoria", JSON.stringify(this.selecionado), { headers: { 'Content-Type': 'application/json' } })
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
    } else {
      alert("Preencha todos os campos");
    }
  }

  remover() {
      let valid = confirm("Deseja remover?");
      if (valid) {
        axios.delete("https://localhost:44389/" + "api/Categoria/"+this.selecionado.id)
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
