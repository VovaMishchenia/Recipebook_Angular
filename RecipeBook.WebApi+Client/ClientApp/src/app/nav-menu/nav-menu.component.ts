import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isCollapsed=true;
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }
constructor(private router:Router){}
  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  pattern:string="";
  search()
  { 
    localStorage.setItem("searchPattern",this.pattern);
    this.router.navigate(["/search"]);
  }
  signOut()
  {
    this.router.navigate(["/sign-in"]);
    localStorage.removeItem("token");
  }
  ngOnInit() {

  }

}
