import { Component, OnInit } from '@angular/core';
import { RecipeModel } from '../models/recipe.model';
import { RecipeService } from '../Services/recipe.service';

@Component({
  selector: 'admin-area',
  templateUrl: './admin-area.component.html',
  styleUrls: ['./admin-area.component.css']
})
export class AdminAreaComponent implements OnInit {

  constructor(private recipeService: RecipeService) { }
  recipes: RecipeModel[];
  ngOnInit() {
    this.recipes = this.recipeService.getRecipes();
  }
  

}
