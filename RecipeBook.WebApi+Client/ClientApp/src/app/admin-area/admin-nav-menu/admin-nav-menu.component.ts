import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'admin-nav-menu',
  templateUrl: './admin-nav-menu.component.html',
  styleUrls: ['./admin-nav-menu.component.css']
})
export class AdminNavMenuComponent implements OnInit {

  isCollapsed = true;
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }
  constructor(private router: Router) { }
  toggle() {
    this.isExpanded = !this.isExpanded;
  }


  signOut() {
    this.router.navigate(["/sign-in"]);
    localStorage.removeItem("token");
  }
  ngOnInit() {

  }

}
