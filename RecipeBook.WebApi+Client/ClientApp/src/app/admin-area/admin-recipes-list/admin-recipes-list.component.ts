import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotifierService } from 'angular-notifier';
import { NgxSpinnerService } from 'ngx-spinner';
import { NgxSpinner } from 'ngx-spinner/lib/ngx-spinner.enum';
import { CuisineModel } from 'src/app/models/cuisine.model';
import { RecipeModel } from 'src/app/models/recipe.model';
import { TypeModel } from 'src/app/models/type.model';
import { RecipeService } from 'src/app/Services/recipe.service';

@Component({
  selector: 'admin-recipes-list',
  templateUrl: './admin-recipes-list.component.html',
  styleUrls: ['./admin-recipes-list.component.css']
})
export class AdminRecipesListComponent implements OnInit {

  constructor(private recipeService: RecipeService,
    private spinner: NgxSpinnerService,
    private router: Router, private notifier: NotifierService) { }
  @Input() recipes: RecipeModel[];
  cuisines: CuisineModel[];
  types: TypeModel[];
  ngOnInit() {
    this.cuisines = this.recipeService.getCuisines();
    this.types = this.recipeService.getTypes();
  }
  delete(event, id: number) {

    this.recipeService.deleteRecipe(id);
    this.spinner.show()
    window.location.reload();
  }
  show(event, id: number) {
    let recipe: RecipeModel;
    for (let item of this.recipes) {
      if (item.id == id) {
        recipe = item;
        break;
      }
    }
    localStorage.setItem("recipe", JSON.stringify(recipe));
    this.router.navigate(["/admin-show-recipe"]);
  }

  deleteCuisine(event, id: number) {
    let contain: boolean = false;
    for (let item of this.recipes) {
      if (item.cuisineId == id) {
        contain = true;
        break;
      }
    }
    if (contain) {
      this.notifier.hideAll();
      this.notifier.notify("error", "You can't delete this cuisine, because there are some recipes that  have it");
    }
    else {
      console.log(id);
      this.recipeService.deleteCuisine(id);
      this.spinner.show()
      window.location.reload();
    }

    
  }

  deleteType(event, id: number) {
    let contain: boolean = false;
    for (let item of this.recipes) {
      if (item.typeId == id) {
        contain = true;
        break;
      }
    }
    if (contain) {
      this.notifier.hideAll();
      this.notifier.notify("error", "You can't delete this type, because there are some recipes that  have it");
    }
    else {
      console.log(id);
      this.recipeService.deleteType(id);
      this.spinner.show()
      window.location.reload();
    }

    
  }
}
