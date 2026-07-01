import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { RouterLink, RouterLinkActive } from "@angular/router";
import { GifService } from '../../services/gifts.service';

interface MenuOption{
  label: string;
  subLabel: string;
  route: string;
  icon: string
}

@Component({
  selector: 'app-side-menu-options',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './side-menu-options.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SideMenuOptions {

  gifService = inject(GifService);

  
  menuOptions: MenuOption[] = [
    {
      icon: 'fa-solid fa-chart fa-chart-line',
      label: 'Trading',
      subLabel: 'Gifs Populars',
      route: '/dashboard/trading'
    },
    {
      icon: 'fa-solid fa-magnifyinf-glass',
      label: 'Search',
      subLabel: 'Search Gifs',
      route: '/dashboard/search'
    }
  ]
}
