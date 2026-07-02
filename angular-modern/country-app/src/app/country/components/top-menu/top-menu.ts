import { ChangeDetectionStrategy, Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-top-menu',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './top-menu.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TopMenu {}
