import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoriasComponent } from './categorias/categorias.component';
import { ProdutosComponent } from './produtos/produtos.component';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { VendasComponent } from './vendas/vendas.component';


const routes: Routes = [
  { path: 'produtos', component: ProdutosComponent },
  { path: 'categorias', component: CategoriasComponent },
  { path: 'usuarios', component: UsuariosComponent },
  { path: 'vendas', component: VendasComponent },
  { path: '',   redirectTo: '/produtos', pathMatch: 'full' },
  { path: '**', redirectTo: '/produtos', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
