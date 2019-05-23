proc start_step { step } {
  set stopFile ".stop.rst"
  if {[file isfile .stop.rst]} {
    puts ""
    puts "*** Halting run - EA reset detected ***"
    puts ""
    puts ""
    return -code error
  }
  set beginFile ".$step.begin.rst"
  set platform "$::tcl_platform(platform)"
  set user "$::tcl_platform(user)"
  set pid [pid]
  set host ""
  if { [string equal $platform unix] } {
    if { [info exist ::env(HOSTNAME)] } {
      set host $::env(HOSTNAME)
    }
  } else {
    if { [info exist ::env(COMPUTERNAME)] } {
      set host $::env(COMPUTERNAME)
    }
  }
  set ch [open $beginFile w]
  puts $ch "<?xml version=\"1.0\"?>"
  puts $ch "<ProcessHandle Version=\"1\" Minor=\"0\">"
  puts $ch "    <Process Command=\".planAhead.\" Owner=\"$user\" Host=\"$host\" Pid=\"$pid\">"
  puts $ch "    </Process>"
  puts $ch "</ProcessHandle>"
  close $ch
}

proc end_step { step } {
  set endFile ".$step.end.rst"
  set ch [open $endFile w]
  close $ch
}

proc step_failed { step } {
  set endFile ".$step.error.rst"
  set ch [open $endFile w]
  close $ch
}

set_msg_config -id {HDL 9-1061} -limit 100000
set_msg_config -id {HDL 9-1654} -limit 100000

start_step init_design
set ACTIVE_STEP init_design
set rc [catch {
  create_msg_db init_design.pb
  create_project -in_memory -part xc7a100tcsg324-1
  set_property board_part digilentinc.com:nexys4:part0:1.1 [current_project]
  set_property design_mode GateLvl [current_fileset]
  set_param project.singleFileAddWarning.threshold 0
  set_property webtalk.parent_dir C:/Users/farha/Uart_Book/Uart_Book.cache/wt [current_project]
  set_property parent.project_path C:/Users/farha/Uart_Book/Uart_Book.xpr [current_project]
  set_property ip_output_repo C:/Users/farha/Uart_Book/Uart_Book.cache/ip [current_project]
  set_property ip_cache_permissions {read write} [current_project]
  add_files -quiet C:/Users/farha/Uart_Book/Uart_Book.runs/synth_1/UART_TEST.dcp
  read_xdc C:/Users/farha/Downloads/digilent-xdc-master/digilent-xdc-master/Nexys-4-Master.xdc
  link_design -top UART_TEST -part xc7a100tcsg324-1
  write_hwdef -file UART_TEST.hwdef
  close_msg_db -file init_design.pb
} RESULT]
if {$rc} {
  step_failed init_design
  return -code error $RESULT
} else {
  end_step init_design
  unset ACTIVE_STEP 
}

start_step opt_design
set ACTIVE_STEP opt_design
set rc [catch {
  create_msg_db opt_design.pb
  opt_design 
  write_checkpoint -force UART_TEST_opt.dcp
  catch { report_drc -file UART_TEST_drc_opted.rpt }
  close_msg_db -file opt_design.pb
} RESULT]
if {$rc} {
  step_failed opt_design
  return -code error $RESULT
} else {
  end_step opt_design
  unset ACTIVE_STEP 
}

start_step place_design
set ACTIVE_STEP place_design
set rc [catch {
  create_msg_db place_design.pb
  implement_debug_core 
  place_design 
  write_checkpoint -force UART_TEST_placed.dcp
  catch { report_io -file UART_TEST_io_placed.rpt }
  catch { report_utilization -file UART_TEST_utilization_placed.rpt -pb UART_TEST_utilization_placed.pb }
  catch { report_control_sets -verbose -file UART_TEST_control_sets_placed.rpt }
  close_msg_db -file place_design.pb
} RESULT]
if {$rc} {
  step_failed place_design
  return -code error $RESULT
} else {
  end_step place_design
  unset ACTIVE_STEP 
}

start_step route_design
set ACTIVE_STEP route_design
set rc [catch {
  create_msg_db route_design.pb
  route_design 
  write_checkpoint -force UART_TEST_routed.dcp
  catch { report_drc -file UART_TEST_drc_routed.rpt -pb UART_TEST_drc_routed.pb -rpx UART_TEST_drc_routed.rpx }
  catch { report_methodology -file UART_TEST_methodology_drc_routed.rpt -rpx UART_TEST_methodology_drc_routed.rpx }
  catch { report_timing_summary -warn_on_violation -max_paths 10 -file UART_TEST_timing_summary_routed.rpt -rpx UART_TEST_timing_summary_routed.rpx }
  catch { report_power -file UART_TEST_power_routed.rpt -pb UART_TEST_power_summary_routed.pb -rpx UART_TEST_power_routed.rpx }
  catch { report_route_status -file UART_TEST_route_status.rpt -pb UART_TEST_route_status.pb }
  catch { report_clock_utilization -file UART_TEST_clock_utilization_routed.rpt }
  close_msg_db -file route_design.pb
} RESULT]
if {$rc} {
  write_checkpoint -force UART_TEST_routed_error.dcp
  step_failed route_design
  return -code error $RESULT
} else {
  end_step route_design
  unset ACTIVE_STEP 
}

