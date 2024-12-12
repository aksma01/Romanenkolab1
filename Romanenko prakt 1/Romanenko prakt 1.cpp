#include <windows.h>
#include <iostream>
#include <vector>
#include <thread>

struct ProcessInfo {
    PROCESS_INFORMATION pi;
    std::wstring name;
    bool isRunning;
};

bool createProcess(const std::wstring& programPath, ProcessInfo& processInfo) {
    STARTUPINFOW si = { sizeof(si) };
    PROCESS_INFORMATION pi;

    if (!CreateProcessW(
        NULL,
        const_cast<LPWSTR>(programPath.c_str()),
        NULL,
        NULL,
        FALSE,
        0,
        NULL,
        NULL,
        &si,
        &pi
    )) {
        std::wcerr << L"Failed to create process: " << programPath << L". Error code: " << GetLastError() << std::endl;
        return false;
    }

    processInfo.pi = pi;
    processInfo.name = programPath;
    processInfo.isRunning = true;

    std::wcout << L"Process created: " << programPath << L" with PID " << pi.dwProcessId << std::endl;
    return true;
}

void monitorProcess(ProcessInfo& processInfo, int timeoutSeconds) {
    DWORD waitResult = WaitForSingleObject(processInfo.pi.hProcess, timeoutSeconds * 1000);
    if (waitResult == WAIT_OBJECT_0) {
        DWORD exitCode;
        if (GetExitCodeProcess(processInfo.pi.hProcess, &exitCode)) {
            std::wcout << L"Process " << processInfo.name << L" completed with exit code: " << exitCode << std::endl;
        }
        else {
            std::wcerr << L"Failed to get exit code for process: " << processInfo.name << std::endl;
        }
    }
    else if (waitResult == WAIT_TIMEOUT) {
        std::wcerr << L"Process " << processInfo.name << L" is taking too long. Terminating..." << std::endl;
        if (TerminateProcess(processInfo.pi.hProcess, 1)) {
            std::wcout << L"Process " << processInfo.name << L" terminated due to timeout." << std::endl;
        }
        else {
            std::wcerr << L"Failed to terminate process: " << processInfo.name << std::endl;
        }
    }
    processInfo.isRunning = false;

    CloseHandle(processInfo.pi.hProcess);
    CloseHandle(processInfo.pi.hThread);
}

void runMultipleProcesses(const std::vector<std::wstring>& programPaths, int timeoutSeconds) {
    std::vector<ProcessInfo> processes;

    for (const auto& path : programPaths) {
        ProcessInfo processInfo;
        if (createProcess(path, processInfo)) {
            processes.push_back(processInfo);
        }
    }

    std::vector<std::thread> threads;
    for (auto& process : processes) {
        threads.emplace_back(monitorProcess, std::ref(process), timeoutSeconds);
    }

    for (auto& thread : threads) {
        if (thread.joinable()) {
            thread.join();
        }
    }
}

int main() {
    std::vector<std::wstring> programs = {
        L"notepad.exe",
    };

    std::wcout << L"Starting processes..." << std::endl;
    runMultipleProcesses(programs, 10);

    std::wcout << L"All processes have been monitored." << std::endl;
    return 0;
}
