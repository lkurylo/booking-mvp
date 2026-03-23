import { Routes } from '@angular/router';

import { MakeAppointmentComponent } from './appointments/make-appointment.component/make-appointment.component';
import { loadBarbersResolver } from './appointments/resolvers/load-barbers-resolver';

export const routes: Routes = [
  {
    path: '', component: MakeAppointmentComponent, resolve:{
      barbers: loadBarbersResolver
    }
  }
];
