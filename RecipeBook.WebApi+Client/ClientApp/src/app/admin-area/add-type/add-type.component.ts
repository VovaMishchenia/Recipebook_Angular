import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotifierService } from 'angular-notifier';
import { NgxSpinnerService } from 'ngx-spinner';
import { RecipeService } from 'src/app/Services/recipe.service';

@Component({
  selector: 'app-add-type',
  templateUrl: './add-type.component.html',
  styleUrls: ['./add-type.component.css']
})
export class AddTypeComponent implements OnInit {

  constructor(private notifier: NotifierService,
    private router: Router,
    private recipeService: RecipeService,
    private spinner:NgxSpinnerService) { }
  name: string="";
  ngOnInit() {
  }

  add(){
    if(this.name=="")
    {
      this.notifier.hideAll();
      this.notifier.notify("error", "Please set name of type");
    }
    else
    {
      this.notifier.hideAll();
      console.log(this.name);
      this.recipeService.addType(this.name);
      this.spinner.show();
      this.router.navigate(["/admin-pannel"]).then(()=>window.location.reload());
    }

  }

}
