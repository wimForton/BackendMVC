import { Routes } from "@angular/router";
import { MidiListComponent } from "./gui/midi-list/midi-list.component";
import { MididetailComponent } from "./gui/mididetail/mididetail.component";

const routeConfig: Routes = [
    {path: '',
    component: MidiListComponent,
    title: 'Homepage'
    },
    {path: 'mididetails/:id',
    component: MididetailComponent,
    title: 'midi details'
    }
];

export default routeConfig;