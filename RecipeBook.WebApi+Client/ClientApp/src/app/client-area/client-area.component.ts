import { Component, OnInit } from '@angular/core';
import { NgModel } from '@angular/forms';
import { RecipeModel } from '../models/recipe.model';
import { RecipeService } from '../Services/recipe.service';
@Component({
  selector: 'client-area',
  templateUrl: './client-area.component.html',
  styleUrls: ['./client-area.component.css']
})
export class ClientAreaComponent implements OnInit {

  constructor(private recipeService:RecipeService) { 

  }
  recipes:RecipeModel[];
  ngOnInit() {
    this.recipes=this.recipeService.recipes;
  }

}
