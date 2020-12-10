import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AdminAreaComponent } from './admin-area/admin-area.component';
import { ClientAreaComponent } from './client-area/client-area.component';
import { SiginInComponent } from './sigin-in/sigin-in.component';
import { SiginUpComponent } from './sigin-up/sigin-up.component';
import { AppRoutingModule } from './app-routing.module';
import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NotifierModule, NotifierOptions } from 'angular-notifier';
import { TokenInterceptor } from './interceptor';
import { RecipesListComponent } from './client-area/recipes-list/recipes-list.component';
import { RecipeItemComponent } from './client-area/recipe-item/recipe-item.component';
import {NgbPaginationModule, NgbAlertModule, NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { CarouselComponent } from './client-area/carousel/carousel.component';
import { RatingModule } from 'ng-starrating';
import { AddFormComponent } from './client-area/add-form/add-form.component';
import { RecipeModel } from './models/recipe.model';
import { ShowRecipeComponent } from './client-area/show-recipe/show-recipe.component';
import { SearchComponent } from './client-area/search/search.component';
import { AdminNavMenuComponent } from './admin-area/admin-nav-menu/admin-nav-menu.component';
import { AdminRecipesListComponent } from './admin-area/admin-recipes-list/admin-recipes-list.component';
import { AdminShowRecipeComponent } from './admin-area/admin-show-recipe/admin-show-recipe.component';
import { AddTypeComponent } from './admin-area/add-type/add-type.component';
import { AddCuisineComponent } from './admin-area/add-cuisine/add-cuisine.component';
const config:NotifierOptions={
  position:{
    horizontal:{
      position:'right',
    },
    vertical:{
      position:'top'
    }
  }
}
 
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AdminAreaComponent,
    ClientAreaComponent,
    SiginInComponent,
    SiginUpComponent,
    RecipesListComponent,
    RecipeItemComponent,
    CarouselComponent,
    AddFormComponent,
    ShowRecipeComponent,
    SearchComponent,
    AdminNavMenuComponent,
    AdminRecipesListComponent,
    AdminShowRecipeComponent,
    AddTypeComponent,
    AddCuisineComponent,
   

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    NgxSpinnerModule,
    BrowserAnimationsModule,
    NotifierModule,
    NgbPaginationModule, 
    NgbAlertModule,
    RatingModule,
    NgbModule

  ],
 
  providers: [
    NgxSpinnerService,
    {provide:HTTP_INTERCEPTORS,useClass:TokenInterceptor,multi:true},
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
