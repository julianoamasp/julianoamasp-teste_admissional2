import { Component, OnInit } from '@angular/core';
import axios from 'axios';

@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.css']
})
export class ProdutosComponent implements OnInit {
  categorias: any = [];
  produtos: any = [];
  rascunho: any = {
    id: 0,
    nome: "",
    descricao: "",
    preco: 0,
    estoque: 1,
    categoriaId: 0,
    categoria: {}
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
      nome: "",
      descricao: "",
      preco: 0,
      estoque: 1,
      categoriaId: 0,
      categoria: {}
    };

  }

  pegarNomeCategoriaPorId(id:any){
    for(let x = 0; x < this.categorias.length; x++){
      if(this.categorias[x].id == id){
          return this.categorias[x].nome;
      }
    }
    return "Categoria não existe!";
  }

  async buscar() {
    axios.get("https://localhost:44389/" + "api/Categoria")
      .then(res => {
        this.categorias = JSON.parse(JSON.stringify(res.data));
      })
      .catch(err => {
        console.log(err);
      });
    axios.get("https://localhost:44389/" + "api/Produto")
      .then(res => {
        this.produtos = JSON.parse(JSON.stringify(res.data));
      })
      .catch(err => {
        console.log(err);
      });
  }

  adicionar() {

    if (this.rascunho.nome != "" && this.rascunho.descricao != "") {
      let valid = confirm("Deseja adicionar?");
      if (valid) {
        axios.post("https://localhost:44389/" + "api/Produto", JSON.stringify(this.rascunho), { headers: { 'Content-Type': 'application/json' } })
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
        axios.put("https://localhost:44389/" + "api/Produto", JSON.stringify(this.selecionado), { headers: { 'Content-Type': 'application/json' } })
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
      axios.delete("https://localhost:44389/" + "api/Produto/" + this.selecionado.id)
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
