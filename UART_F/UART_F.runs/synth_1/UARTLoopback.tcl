# 
# Synthesis run script generated by Vivado
# 

set_param xicom.use_bs_reader 1
set_msg_config -id {HDL 9-1061} -limit 100000
set_msg_config -id {HDL 9-1654} -limit 100000
create_project -in_memory -part xc7a100tcsg324-1

set_param project.singleFileAddWarning.threshold 0
set_param project.compositeFile.enableAutoGeneration 0
set_param synth.vivado.isSynthRun true
set_property webtalk.parent_dir C:/Users/farha/UART_F/UART_F.cache/wt [current_project]
set_property parent.project_path C:/Users/farha/UART_F/UART_F.xpr [current_project]
set_property default_lib xil_defaultlib [current_project]
set_property target_language Verilog [current_project]
set_property board_part digilentinc.com:nexys4:part0:1.1 [current_project]
set_property ip_output_repo c:/Users/farha/UART_F/UART_F.cache/ip [current_project]
set_property ip_cache_permissions {read write} [current_project]
read_verilog -library xil_defaultlib {
  C:/Users/farha/Downloads/ClockDiv.v
  C:/Users/farha/Downloads/UART.v
  C:/Users/farha/Downloads/UARTLoopback.v
}
foreach dcp [get_files -quiet -all *.dcp] {
  set_property used_in_implementation false $dcp
}
read_xdc C:/Users/farha/Downloads/digilent-xdc-master/digilent-xdc-master/Nexys-4-Master.xdc
set_property used_in_implementation false [get_files C:/Users/farha/Downloads/digilent-xdc-master/digilent-xdc-master/Nexys-4-Master.xdc]


synth_design -top UARTLoopback -part xc7a100tcsg324-1


write_checkpoint -force -noxdef UARTLoopback.dcp

catch { report_utilization -file UARTLoopback_utilization_synth.rpt -pb UARTLoopback_utilization_synth.pb }