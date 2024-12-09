public interface IMedicalApiService
{
    Task<IEnumerable<MedicalRecord>> GetAllMedicalRecordsAsync();
    Task<MedicalRecord> GetMedicalRecordByIdAsync(int id);
    Task<IEnumerable<Specialty>> GetAllSpecialtiesAsync();
    Task<IEnumerable<AvailabilityMode>> GetAllAvailabilityModesAsync();
}

public class MedicalApiService : IMedicalApiService
{
    private readonly HttpClient _httpClient;

    public MedicalApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("MedicalAPI");
    }

    public async Task<IEnumerable<MedicalRecord>> GetAllMedicalRecordsAsync()
    {
        var response = await _httpClient.GetAsync("api/Medical");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<MedicalRecord>>();
    }

    public async Task<MedicalRecord> GetMedicalRecordByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/Medical/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<MedicalRecord>();
    }

    public async Task<IEnumerable<Specialty>> GetAllSpecialtiesAsync()
    {
        var response = await _httpClient.GetAsync("api/Specialties");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<Specialty>>();
    }

    public async Task<IEnumerable<AvailabilityMode>> GetAllAvailabilityModesAsync()
    {
        var response = await _httpClient.GetAsync("api/AvailabilityModes");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<AvailabilityMode>>();
    }
}
