import { Component, Inject, Injectable, Input, OnInit } from '@angular/core';
import { RecipeModel } from 'src/app/models/recipe.model';
import { RecipeService } from 'src/app/Services/recipe.service';
@Component({
  selector: 'recipes-list',
  templateUrl: './recipes-list.component.html',
  styleUrls: ['./recipes-list.component.css']
})
@Injectable()
export class RecipesListComponent implements OnInit {

  constructor(private recipeService:RecipeService) { }
  @Input() recipes:RecipeModel[];

  ngOnInit() {
    //let recipesList=new Array<RecipeModel>();
    //this.recipes =this.recipeService.getAllRecipes();
    //this.recipes=this.recipeService.recipes;
    console.log(this.recipes);
    console.log();
  }

}
