import { Component, OnInit } from '@angular/core';
import { NgbRatingConfig } from '@ng-bootstrap/ng-bootstrap';
import { RecipeModel } from 'src/app/models/recipe.model';

@Component({
  selector: 'app-admin-show-recipe',
  templateUrl: './admin-show-recipe.component.html',
  styleUrls: ['./admin-show-recipe.component.css']
})
export class AdminShowRecipeComponent implements OnInit {

  constructor(private config: NgbRatingConfig) {
    config.max = 5;
    config.readonly = true;
  }
  recipe: RecipeModel;
  ngOnInit() {
    this.recipe = JSON.parse(localStorage.getItem("recipe"));

  }
}
