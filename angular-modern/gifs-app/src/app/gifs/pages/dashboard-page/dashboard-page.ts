import {  Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SideMenu } from "../../component/side-menu/side-menu";

@Component({
  selector: 'app-dashboard-page',
  imports: [RouterOutlet, SideMenu],
  templateUrl: './dashboard-page.html',
})
export default class DashboardPage {}
