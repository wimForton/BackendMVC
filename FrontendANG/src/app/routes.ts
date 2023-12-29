import { Routes } from "@angular/router";
import { MidiListComponent } from "./gui/midi-list/midi-list.component";

const routeConfig: Routes = [
    {path: '',
    component: MidiListComponent,
    title: 'Homepage'
}
];

export default routeConfig;