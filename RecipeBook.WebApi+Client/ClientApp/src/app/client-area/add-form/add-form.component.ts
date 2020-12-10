import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotifierService } from 'angular-notifier';
import { NgxSpinnerService } from 'ngx-spinner';
import { title } from 'process';
import { CuisineModel } from 'src/app/models/cuisine.model';
import { RecipeModel } from 'src/app/models/recipe.model';
import { TypeModel } from 'src/app/models/type.model';
import { RecipeService } from 'src/app/Services/recipe.service';

@Component({
  selector: 'app-add-form',
  templateUrl: './add-form.component.html',
  styleUrls: ['./add-form.component.css']
})
export class AddFormComponent implements OnInit {

  constructor(private notifier: NotifierService,
    private router: Router,
    private recipeService: RecipeService,
    private spinner:NgxSpinnerService) { }

  cuisines: CuisineModel[];
  types: TypeModel[];
  model = new RecipeModel();
  rating:number=1;

  add() {
    if (this.model.name == "" || this.model.instruction == "" ||
      this.model.ingredients == "" || this.model.cuisine == null ||
      this.model.type == null || this.model.photoPath == "" ||
      this.model.calories == null || this.model.cookingTime == null ||
      this.model.rating == null) {
      this.notifier.hideAll();
      this.notifier.notify("error", "Please complete all gaps");
      

    }
    else {
      this.notifier.hideAll();
      for (var item of this.cuisines) {
        if (item.name == this.model.cuisine) {
          this.model.cuisineId = item.id;
        }
      }
      for (var item of this.types) {
        if (item.name == this.model.type) {
          this.model.typeId = item.id;
        }
      }
      this.model.rating=+this.rating;
      console.log(this.model);
      this.recipeService.addRecipe(this.model);
      this.spinner.show();
      this.router.navigate(["/client-area"]).then(()=>window.location.reload());
      //  this.router.navigateByUrl('/',{skipLocationChange:true}).then(()=>
      //  this.router.navigate(["/client-area"]));
    }
  }
  ngOnInit() {
    this.cuisines = this.recipeService.getCuisines();
    this.types = this.recipeService.getTypes();

  }

}
