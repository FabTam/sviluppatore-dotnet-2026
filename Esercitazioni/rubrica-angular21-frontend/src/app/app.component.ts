import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {NavbarComponent} from './shared/components/navbar/navbar.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  template: `
  <app-navbar></app-navbar>
  <main class ="container page">
   <router-outlet></router-outlet>
  </main>
  `
})
export class App {
  protected readonly title = signal('rubrica-angular21-frontend');
}
