import { ChangeDetectionStrategy, Component } from '@angular/core';
import { SideMenuHeader } from "../side-menu-header/side-menu-header";
import { SideMenuOptions } from "../side-menu-options/side-menu-options";

@Component({
  selector: 'app-side-menu',
  imports: [SideMenuHeader, SideMenuOptions],
  templateUrl: './side-menu.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SideMenu {}
