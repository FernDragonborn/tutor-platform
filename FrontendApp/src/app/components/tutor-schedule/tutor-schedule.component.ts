import { Component, OnInit } from '@angular/core';
import { ScheduleService } from 'src/app/services/shedule.service';

@Component({
  selector: 'app-schedule',
  templateUrl: './tutor-schedule.component.html',
  styleUrls: ['./tutor-schedule.component.css']
})
export class ScheduleComponent implements OnInit {
  timeSlots: string[] = [];
  days: string[] = ["Понеділок", "Вівторок", "Середа", "Четвер", "П'ятниця", "Субота", "Неділя"];
  schedule: boolean[][];

  constructor(private scheduleService: ScheduleService) { }

  ngOnInit(): void {
    const startTime = 8;
    const endTime = 21;
    for (let hour = startTime; hour <= endTime; hour++) {
      this.timeSlots.push(`${hour < 10 ? '0' : ''}${hour}:00`);
      this.timeSlots.push(`${hour < 10 ? '0' : ''}${hour}:30`);
    }

    // Отримуємо розклад
    this.scheduleService.getSchedule().subscribe(data => {
      this.schedule = data;
    });
  }

  toggleAvailability(timeSlot: string, day: string): void {
    const timeSlotIndex = this.timeSlots.indexOf(timeSlot);
    const dayIndex = this.days.indexOf(day);
    this.schedule[timeSlotIndex][dayIndex] = !this.schedule[timeSlotIndex][dayIndex];
    this.scheduleService.updateSchedule(this.schedule).subscribe();
  }

  isAvailable(timeSlot: string, day: string): boolean {
    const timeSlotIndex = this.timeSlots.indexOf(timeSlot);
    const dayIndex = this.days.indexOf(day);
    return this.schedule[timeSlotIndex][dayIndex];
  }
}