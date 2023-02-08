import { Component } from '@angular/core';

@Component({
  selector: 'app-footer',
  template: `
    <footer class="sticky-footer bg-white">
      <div class="container my-auto">
        <div class="copyright text-center my-auto">
          <span>Copyright &copy; Your Website 2020</span>
        </div>
      </div>
    </footer>
  `,
  styleUrls: ['./footer.component.scss'],
})
export class FooterComponent {}
