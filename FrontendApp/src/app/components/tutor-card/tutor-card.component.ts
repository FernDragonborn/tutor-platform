import { Component, Input } from '@angular/core';
import { TutorDto } from 'src/app/models/tutor.model';

@Component({
  selector: 'app-tutor-card',
  templateUrl: './tutor-card.component.html',
  styleUrls: ['./tutor-card.component.scss']
})
export class TutorCardComponent {
  @Input() tutor: TutorDto;

}
