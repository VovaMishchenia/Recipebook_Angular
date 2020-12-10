import { Component, OnInit } from '@angular/core';
import { RecipeModel } from 'src/app/models/recipe.model';
import { RecipeService } from 'src/app/Services/recipe.service';

@Component({
  selector: 'search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  constructor(private recipeService:RecipeService) { }
  searchPattern: string;
  recipes:RecipeModel[];
  ngOnInit() {
    this.searchPattern = localStorage.getItem("searchPattern");
    this.recipes=this.recipeService.getSearchRecipes(this.searchPattern);
  }

}
