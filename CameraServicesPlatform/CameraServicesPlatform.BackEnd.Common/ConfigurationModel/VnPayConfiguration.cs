﻿namespace CameraServicesPlatform.BackEnd.Common.ConfigurationModel;

public class VnPayConfiguration
{
    public string? TmnCode { get; set; }
    public string? HashSecret { get; set; }
    public string? BaseUrl { get; set; }
    public string? Command { get; set; }
    public string? CurrCode { get; set; }
    public string? Version { get; set; }
    public string? Locale { get; set; }
    public string? Api { get; set; }
    public string? ReturnUrl { get; set; }
}