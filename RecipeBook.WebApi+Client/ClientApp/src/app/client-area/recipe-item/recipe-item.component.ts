import { Component, Input, OnInit } from '@angular/core';
import { RecipeModel } from 'src/app/models/recipe.model';
import { NgbModal, NgbModule, NgbRatingConfig, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { StarRatingComponent } from 'ng-starrating';
import { RecipeService } from 'src/app/Services/recipe.service';
import { ResourceLoader } from '@angular/compiler';
import { Router } from '@angular/router';
import { CuisineModel } from 'src/app/models/cuisine.model';
import { TypeModel } from 'src/app/models/type.model';
import { NotifierService } from 'angular-notifier';
import { NgxSpinnerService } from 'ngx-spinner';
@Component({
  selector: 'recipe-item',
  templateUrl: './recipe-item.component.html',
  styleUrls: ['./recipe-item.component.css'],
  providers: [NgbRatingConfig]
})
export class RecipeItemComponent implements OnInit {

  @Input() recipe: RecipeModel;
  name: string;
  instruction: string;
  ingredients: string;
  photoPath: string;
  type: string;
  cuisine: string;
  cookingTime: number;
  rating: number;
  calories: number;



  closeResult: string;
  cuisines: CuisineModel[];
  types: TypeModel[];

  constructor(config: NgbRatingConfig,
    private recipeService: RecipeService,
    private router: Router,
    private modalService: NgbModal,
    private notifier: NotifierService,
    private spinner:NgxSpinnerService
  ) {
    config.max = 5;
    config.readonly = true;
    

  }

  open(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }
  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

  delete() {
    console.log(this.recipe.id);
    this.recipeService.deleteRecipe(this.recipe.id);
    this.spinner.show();
    window.location.reload();
  }
  show()
  {
    localStorage.setItem("recipe",JSON.stringify(this.recipe));
    this.router.navigate(["/show-recipe"]);
  }

update(){
  let model:RecipeModel=new RecipeModel;

  if (this.name == "" || this.instruction == "" ||
  this.ingredients == "" || this.cuisine == null ||
  this.type == null || this.photoPath == "" ||
  this.calories == null || this.cookingTime == null ||
  this.rating == null) {
  this.notifier.hideAll();
  this.notifier.notify("error", "Please complete all gaps");
}
else
{
  this.notifier.hideAll();
  model.name=this.name;
  model.instruction=this.instruction;
  model.ingredients=this.ingredients;
  model.photoPath=this.photoPath;
  model.cuisine=this.cuisine;
  model.type=this.type;
  model.cookingTime=this.cookingTime;
  model.id=this.recipe.id;
  model.calories=this.calories;
  for (var item of this.cuisines) {
    if (item.name == this.cuisine) {
      model.cuisineId = item.id;
    }
  }
  for (var item of this.types) {
    if (item.name == this.type) {
      model.typeId = item.id;
    }
  }
}
model.rating=+this.rating;
this.recipeService.updateRecipe(model);
document.getElementById("close").click();
//  this.router.navigateByUrl('/',{skipLocationChange:true}).then(()=>
//  this.router.navigate(["/client-area"]));
this.spinner.show();
 window.location.reload();

}

  ngOnInit() {
    this.cuisines = this.recipeService.getCuisines();
    this.types = this.recipeService.getTypes();

    this.name = this.recipe.name;
    this.instruction = this.recipe.instruction;
    this.ingredients = this.recipe.ingredients;
    this.photoPath = this.recipe.photoPath;
    this.type = this.recipe.type;
    this.cuisine = this.recipe.cuisine;
    this.cookingTime = this.recipe.cookingTime;
    this.rating = this.recipe.rating;
    this.calories = this.recipe.calories;
  }

}
