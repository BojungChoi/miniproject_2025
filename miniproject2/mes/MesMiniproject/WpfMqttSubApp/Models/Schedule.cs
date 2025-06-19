using System;
using System.Collections.Generic;

namespace WpfMqttSubApp.Models;

public partial class Schedule
{
    /// <summary>
    /// 공정계획 순번(자동증가)
    /// </summary>
    public int SchIdx { get; set; }

    public string PlantCode { get; set; } = null!;

    public DateOnly SchDate { get; set; }

    public int LoadTime { get; set; }

    public TimeOnly? SchStartTime { get; set; }

    public TimeOnly? SchEntTime { get; set; }

    public string? SchFacilityId { get; set; }

    public int SchAmount { get; set; }

    public DateTime? RegDt { get; set; }

    public DateTime? ModDt { get; set; }

    public virtual ICollection<Process> Processes { get; set; } = new List<Process>();
}
