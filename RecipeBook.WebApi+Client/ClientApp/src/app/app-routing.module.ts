import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddCuisineComponent } from './admin-area/add-cuisine/add-cuisine.component';
import { AddTypeComponent } from './admin-area/add-type/add-type.component';
import { AdminAreaComponent } from './admin-area/admin-area.component';
import { AdminShowRecipeComponent } from './admin-area/admin-show-recipe/admin-show-recipe.component';
import { AddFormComponent } from './client-area/add-form/add-form.component';
import { ClientAreaComponent } from './client-area/client-area.component';
import { SearchComponent } from './client-area/search/search.component';
import { ShowRecipeComponent } from './client-area/show-recipe/show-recipe.component';
import { HomeComponent } from './home/home.component';
import { SiginInComponent } from './sigin-in/sigin-in.component';
import { SiginUpComponent } from './sigin-up/sigin-up.component';

const routes: Routes = [
{path:'',pathMatch:'full',component:HomeComponent},
{path:'sign-up',pathMatch:'full',component:SiginUpComponent},
{path:'sign-in',pathMatch:'full',component:SiginInComponent},
{path:'admin-pannel',pathMatch:'full',component:AdminAreaComponent},
{path:'client-area',pathMatch:'full',component:ClientAreaComponent},
{path:'addRecipe',pathMatch:'full',component:AddFormComponent},
{path:'show-recipe',pathMatch:'full',component:ShowRecipeComponent},
{path:'search',pathMatch:'full',component:SearchComponent},
{path:'admin-show-recipe',pathMatch:'full',component:AdminShowRecipeComponent},
{path:'add-type',pathMatch:'full',component:AddTypeComponent},
{path:'add-cuisine',pathMatch:'full',component:AddCuisineComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }